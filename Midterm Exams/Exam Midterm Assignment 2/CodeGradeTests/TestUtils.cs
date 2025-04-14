// Do not modify this file

using System.Reflection;

static class TestUtils
{
    // Read-only
    public static void PrintIsFieldReadOnly(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field is null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) field {field.Name} is read-only: {field.IsInitOnly}");
    }

    // Constant
    public static void PrintIsFieldConstant(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field is null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) field {field.Name} is constant: {field.IsLiteral}");
    }

    // Static
    public static void PrintIsFieldStatic(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field is null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) field {field.Name} is static: {field.IsStatic}");
    }

    public static void PrintIsPropertyStatic(Type clsType, string propertyName)
    {
        var property = clsType.GetProperty(propertyName,
            BindingFlags.NonPublic | BindingFlags.Public |
            BindingFlags.Instance | BindingFlags.Static);

        if (property == null)
        {
            Console.WriteLine($"(Class {clsType.Name}) property {propertyName} not found");
            return;
        }

        bool isStatic = (property.GetMethod != null && property.GetMethod.IsStatic) ||
                        (property.SetMethod != null && property.SetMethod.IsStatic);
        Console.WriteLine($"(Class {clsType.Name}) property {propertyName} is static: {isStatic}");
    }

    public static void PrintIsMethodStatic(Type clsType, string methodName)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (method is null)
        {
            PrintMethodNotFoundInClass(clsType, methodName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) method {methodName} is static: {method.IsStatic}");
    }

    public static void PrintIsClassStatic(Type clsType)
    {
        Console.WriteLine($"Class {clsType.Name} is static: " +
            (clsType.IsAbstract && clsType.IsSealed));
    }

    // Polymorphism & Encapsulation
    public static void CheckConstructorsCorrect(Type clsType)
    {
        ConstructorInfo[] constructors = [.. clsType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .OrderBy(c => c.GetParameters().Length)
            .ThenBy(c => string.Join(",", c.GetParameters()
                .Select(p => p.ParameterType.Name)))
            .ThenBy(c => GetAccessModifierRank(c))];


        Console.WriteLine($"Class {clsType.Name} has {constructors.Length} constructor(s):");
        foreach (var constructor in constructors)
        {
            string accessModifier = constructor.IsPublic ? "public" :
                                    constructor.IsPrivate ? "private" :
                                    constructor.IsFamily ? "protected" : "internal";

            string parameters = string.Join(", ", constructor.GetParameters()
                .Select(p => $"{GetFriendlyTypeName(p.ParameterType)}"));

            Console.WriteLine($" - {accessModifier} {clsType.Name}({parameters})");
        }
    }

    // Encapsulation
    public static void PrintAreAccessModFieldCorrect(Type clsType, string fieldName, string modifier)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field == null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        bool flag = modifier switch
        {
            "Public" => field.IsPublic,
            "Family" => field.IsFamily,
            "Private" => field.IsPrivate,
            _ => false,
        };
        Console.WriteLine($"(Class {clsType.Name}) field {fieldName} encapsulation: " +
            $"{(flag ? "Correct!" : "Incorrect.")}");
    }

    public static void PrintAreAccessModsPropertyCorrect(Type clsType, string propertyName, string getTest, string setTest)
    {
        var property = clsType.GetProperty(propertyName,
            BindingFlags.NonPublic | BindingFlags.Public |
            BindingFlags.Instance | BindingFlags.Static);

        if (property == null)
        {
            Console.WriteLine($"(Class {clsType.Name}) property {propertyName} not found. (Are you sure it is a property and not a field?)");
            return;
        }

        if (getTest == null && property.CanRead ||
            getTest != null && !property.CanRead ||
            setTest == null && property.CanWrite ||
            setTest != null && !property.CanWrite)
        {
            PrintAccessModsPropertyIncorrect(clsType, propertyName);
            return;
        }

        if (property.CanRead)
        {
            bool getCorrect = getTest switch
            {
                "Public" => property.GetMethod!.IsPublic,
                "Family" => property.GetMethod!.IsFamily,
                "Private" => property.GetMethod!.IsPrivate,
                _ => false
            };
            if (getCorrect == false)
            {
                PrintAccessModsPropertyIncorrect(clsType, propertyName);
                return;
            }
        }

        if (property.CanWrite)
        {
            bool setCorrect = setTest switch
            {
                "Public" => property.SetMethod!.IsPublic,
                "Family" => property.SetMethod!.IsFamily,
                "Private" => property.SetMethod!.IsPrivate,
                _ => false
            };
            if (setCorrect == false)
            {
                PrintAccessModsPropertyIncorrect(clsType, propertyName);
                return;
            }
        }

        Console.WriteLine($"(Class {clsType.Name}) property {propertyName} encapsulation: Correct!");
    }
    private static void PrintAccessModsPropertyIncorrect(Type clsType, string propertyName)
    {
        Console.WriteLine($"(Class {clsType.Name}) property {propertyName} encapsulation: Incorrect");
    }

    public static void PrintAccessModMethodCorrect(Type clsType, string methodName, string modifier)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName);
            return;
        }

        bool correctModifier = modifier switch
        {
            "Public" => method.IsPublic,
            "Family" => method.IsFamily,
            "Private" => method.IsPrivate,
            _ => false,
        };
        Console.WriteLine($"(Class {clsType.Name}) method {methodName} encapsulation is correct: {correctModifier}");
    }

    static string GetFriendlyTypeName(Type type) => type switch
    {
        { } when type == typeof(string) => "string",
        { } when type == typeof(int) => "int",
        { } when type == typeof(bool) => "bool",
        { } when type == typeof(double) => "double",
        { } when type == typeof(float) => "float",
        { } when type == typeof(decimal) => "decimal",
        { } when type == typeof(object) => "object",
        { } when type == typeof(void) => "void",
        _ when type!.IsGenericType => $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(GetFriendlyTypeName))}>",
        _ => type.FullName ?? type.Name
    };


    private static int GetAccessModifierRank(ConstructorInfo constructor)
    {
        return constructor.IsPublic ? 1 :
               constructor.IsFamily ? 2 :
               constructor.IsAssembly ? 3 :
               constructor.IsPrivate ? 4 :
               5;
    }

    // Inheritance
    public static void PrintDoesClassInheritFrom(Type baseType, Type derivedType)
    {
        Console.WriteLine($"{derivedType} inherits from {baseType}: "
            + derivedType.IsSubclassOf(baseType));
    }

    public static void PrintIsMethodOverridden(Type baseType, Type derivedType, string methodName)
    {
        var baseMethod = baseType.GetMethod(methodName);
        var derivedMethod = derivedType.GetMethod(methodName);
        Console.WriteLine($" - Method {methodName} is overridden in {derivedType}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));
    }

    // Abstraction: interfaces
    public static void PrintIsInterface(Type type)
    {
        Console.WriteLine($"{type.Name} is an Interface: {type.IsInterface}");
    }

    public static void PrintIsInterfaceImplementedBy(Type interfaceType, Type clsType)
    {
        Console.WriteLine($"{interfaceType.Name} is implemented by {clsType}: "
            + interfaceType.IsAssignableFrom(clsType));
    }

    public static void PrintIsPropertySignatureCorrect(Type interfaceType, string propertyName, Type expectedPropertyType,
        bool canRead, bool canWrite)
    {
        var property = interfaceType.GetProperty(propertyName);

        if (property == null)
        {
            Console.WriteLine($"(Interface {interfaceType.Name}) property {propertyName} not found");
            return;
        }

        if (property.PropertyType != expectedPropertyType)
        {
            Console.WriteLine(
                $"(Interface {interfaceType.Name}) property {propertyName}: incorrect type.\n" +
                $" - Expected: {expectedPropertyType}\n" +
                $" - Actual: {property.PropertyType}");
            return;
        }

        bool correct_get_set_accessors = true;
        if (canRead != property.CanRead)
            correct_get_set_accessors = false;
        if (canWrite != property.CanWrite)
            correct_get_set_accessors = false;

        Console.WriteLine($"(Interface {interfaceType.Name}) property {propertyName} has the correct type " +
            $"and the correct get/set accessors: {correct_get_set_accessors}");
    }

    public static void PrintIsMethodSignatureCorrect(Type interfaceType, string methodName, Type expectedReturnType, params Type[] expectedParameterTypes)
    {
        var method = interfaceType.GetMethod(methodName, expectedParameterTypes);

        if (method == null)
        {
            Console.WriteLine($"(Interface {interfaceType.Name}) method {methodName} not found");
            return;
        }

        if (method.ReturnType != expectedReturnType)
        {
            Console.WriteLine($"(Interface {interfaceType.Name}) method {methodName}: incorrect return type. " +
                $"Expected: {expectedReturnType}; Actual: {method.ReturnType}");
            return;
        }

        var parameters = method.GetParameters();
        if (parameters.Length != expectedParameterTypes.Length)
        {
            Console.WriteLine(
                $"(Interface {interfaceType.Name}) method {methodName}: " +
                $"incorrect number of parameters.\n" +
                $" - Expected: {expectedParameterTypes.Length}\n" +
                $" - Actual: {parameters.Length}");
            return;
        }

        bool allParameterTypesCorrect = true;
        for (int i = 0; i < expectedParameterTypes.Length; i++)
        {
            if (parameters[i].ParameterType != expectedParameterTypes[i])
            {
                Console.WriteLine(
                    $"(Interface {interfaceType.Name}) method {methodName}: " +
                    $"incorrect parameter type for parameter {parameters[i].Name}. " +
                    $" - Expected: {expectedParameterTypes[i]}\n" +
                    $" - Actual: {parameters[i].ParameterType}");
                allParameterTypesCorrect = false;
            }
        }

        if (allParameterTypesCorrect)
            Console.WriteLine($"(Interface {interfaceType.Name}) method {methodName}: correct signature!");
    }

    // Abstraction: abstract classes
    public static void PrintIsAbstractClass(Type clsType)
    {
        Console.WriteLine($"{clsType.Name} cannot be instantiated: "
            + (clsType.IsAbstract && !clsType.IsInterface));
    }

    public static void PrintIsAbstractMethod(Type clsType, string methodName)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) method {methodName} has no implementation: {method.IsAbstract}");
    }

    // Helper methods
    private static void PrintFieldNotFoundInClass(Type clsType, string fieldName)
    {
        Console.WriteLine($"(Class {clsType.Name}) field {fieldName} not found. (Are you sure it is a field and not a property?)");
    }

    private static void PrintMethodNotFoundInClass(Type clsType, string methodName)
    {
        Console.WriteLine($"(Class {clsType.Name}) method {methodName} not found");
    }
}