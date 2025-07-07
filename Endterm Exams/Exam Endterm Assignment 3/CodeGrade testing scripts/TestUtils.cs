// Do not modify this file

using System.Reflection;

static class TestUtils
{
    // Read-only
    public static void PrintIsReadOnlyField(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field == null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) field {field.Name} is read-only: {field.IsInitOnly}");
    }

    // Constant
    public static void PrintIsConstantField(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field == null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) field {field.Name} is constant: {field.IsLiteral}");
    }

    // Static
    public static void PrintIsStaticField(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field == null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) field {field.Name} is static: {field.IsStatic}");
    }

    public static void PrintIsStaticProperty(Type clsType, string propertyName)
    {
        var property = clsType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (property == null)
        {
            PrintPropertyNotFoundInClass(clsType, propertyName);
            return;
        }

        bool isStatic = (property.GetMethod != null && property.GetMethod.IsStatic) ||
                        (property.SetMethod != null && property.SetMethod.IsStatic);
        Console.WriteLine($"(Class {clsType.Name}) property {propertyName} is static: {isStatic}");
    }

    public static void PrintIsStaticMethod(Type clsType, string methodName, Type[] parameterTypes)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName, parameterTypes);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) method {methodName} is static: {method.IsStatic}");
    }

    public static void PrintIsStaticClass(Type clsType)
    {
        Console.WriteLine($"Class {clsType.Name} is static: " +
            (clsType.IsAbstract && clsType.IsSealed));
    }

    public static void PrintMethodSignature(Type clsType, string methodName, Type[] parameterTypes)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName, parameterTypes);
            return;
        }

        string accessModifier =
            method.IsPublic ? "public" :
            method.IsFamily ? "protected" :
            method.IsAssembly ? "internal" :
            method.IsPrivate ? "private" :
            "unknown";

        string staticModifier = method.IsStatic ? "static" : "";

        string returnType = GetFriendlyTypeName(method.ReturnType);

        var parameters = method.GetParameters();
        string paramList = string.Join(", ",
            parameters.Select(p => $"{GetFriendlyTypeName(p.ParameterType)} {p.Name}")
        );

        Console.WriteLine($"{accessModifier} " +
            (method.IsStatic ? $"{staticModifier} " : "") +
            $"{returnType} " +
            $"{method.Name}({paramList})");
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
    public static void PrintIsAccessModFieldCorrect(Type clsType, string fieldName, string modifier)
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
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (property == null)
        {
            PrintPropertyNotFoundInClass(clsType, propertyName);
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

    public static void PrintAccessModMethodCorrect(Type clsType, string methodName, Type[] parameterTypes, string modifier)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName, parameterTypes);
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

    private static string GetFriendlyTypeName(Type type) => type switch
    {
        // Tuple types
        _ when type!.FullName?.StartsWith("System.ValueTuple") == true =>
            $"({string.Join(", ", type.GetGenericArguments().Select(GetFriendlyTypeName))})",

        // Handle basic types
        { } when type == typeof(string) => "string",
        { } when type == typeof(int) => "int",
        { } when type == typeof(bool) => "bool",
        { } when type == typeof(double) => "double",
        { } when type == typeof(float) => "float",
        { } when type == typeof(decimal) => "decimal",
        { } when type == typeof(object) => "object",
        { } when type == typeof(void) => "void",

        // Handle arrays (1D, multi-dimensional, and jagged arrays)
        _ when type!.IsArray =>
            $"{GetFriendlyTypeName(type.GetElementType()!)}{new string('[', type.GetArrayRank())}{new string(']', type.GetArrayRank())}",

        // Handle generic types
        _ when type.IsGenericTypeDefinition =>
            $"{type.Name.Split('`')[0]}<>",

        _ when type.IsGenericType =>
            $"{type.Name.Split('`')[0]}<{string.Join(", ", type.GetGenericArguments().Select(GetFriendlyTypeName))}>",

        // Default fallback for other types
        _ => type.FullName ?? type.Name
    };


    private static int GetAccessModifierRank(MethodBase method)
    {
        return method.IsPublic ? 1 :
               method.IsFamily ? 2 :
               method.IsAssembly ? 3 :
               method.IsPrivate ? 4 :
               5;
    }

    // Inheritance
    public static void PrintDoesClassInheritFrom(Type baseType, Type derivedType)
    {
        Console.WriteLine($"{derivedType} inherits from {baseType}: "
            + derivedType.IsSubclassOf(baseType));
    }

    public static void PrintIsVirtualMethod(Type clsType, string methodName, Type[] parameterTypes)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName, parameterTypes);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) method {methodName} is virtual: {method.IsVirtual}");
    }

    public static void PrintIsOverriddenMethod(Type baseType, Type derivedType, Type[] parameterTypes, string methodName)
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        var baseMethod = baseType.GetMethod(methodName, flags,
            null, parameterTypes, null);
        var derivedMethod = derivedType.GetMethod(methodName, flags,
            null, parameterTypes, null);

        if (baseMethod == null)
        {
            PrintMethodNotFoundInClass(baseType, methodName, parameterTypes);
            return;
        }
        if (derivedMethod == null)
        {
            PrintMethodNotFoundInClass(derivedType, methodName, parameterTypes);
            return;
        }

        Console.WriteLine($"(Class {baseType.Name}) method {methodName} is overridden in {derivedType.Name}: " +
            (!ReferenceEquals(baseMethod, derivedMethod)));
    }

    public static void PrintIsVirtualProperty(Type clsType, string propertyName)
    {
        var property = clsType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (property == null)
        {
            PrintPropertyNotFoundInClass(clsType, propertyName);
            return;
        }

        var method = GetFirstAvailableAccessor(property);
        if (method == null)
        {
            Console.WriteLine($"(Class {clsType}) property {propertyName} has no accessible getter or setter.");
            return;
        }

        Console.WriteLine($"(Class {clsType}) property {propertyName} is virtual: " +
            $"{method.IsVirtual}");
    }

    public static void PrintIsOverriddenProperty(Type baseType, Type derivedType, string propertyName)
    {
        var baseProperty = baseType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);
        var derivedProperty = derivedType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        bool isBasePropertyNull = baseProperty == null;
        bool isDerivedPropertyNull = derivedProperty == null;
        if (isBasePropertyNull)
            PrintPropertyNotFoundInClass(baseType, propertyName);
        if (isDerivedPropertyNull)
            PrintPropertyNotFoundInClass(derivedType, propertyName);
        if (isBasePropertyNull || isDerivedPropertyNull) { return; }

        Console.WriteLine($"Property {propertyName} is overridden in {derivedType}: " +
            (!ReferenceEquals(baseProperty, derivedProperty)));
    }

    // Abstraction: interfaces
    public static void PrintIsInterface(Type type)
    {
        Console.WriteLine($"{type.Name} is an Interface: {type.IsInterface}");
    }

    public static void PrintIsInterfaceImplementedBy(Type interfaceType, Type clsType)
    {
        string interfaceName = GetFriendlyTypeName(interfaceType);
        Console.WriteLine($"{interfaceName} is implemented by {clsType.Name}: "
            + interfaceType.IsAssignableFrom(clsType));
    }
    public static void PrintIsInterfaceNotImplementedBy(Type interfaceType, Type clsType)
    {
        string interfaceName = GetFriendlyTypeName(interfaceType);
        Console.WriteLine($"{interfaceName} is NOT implemented by {clsType}: "
            + !interfaceType.IsAssignableFrom(clsType));
    }

    public static void PrintInterfaceMembers(Type interfaceType)
    {
        Console.WriteLine($"Interface {interfaceType.Name} members:");

        Console.WriteLine(" - Methods:");
        var methods = interfaceType
            .GetMethods()
            .OrderBy(m => m.Name)
            .ThenBy(m => string.Join(",", m.GetParameters().Select(p => p.ParameterType.FullName)))
            .ToList();

        foreach (var method in methods)
        {
            var parameters = string.Join(", ", method.GetParameters().Select(p => p.ParameterType.Name));
            Console.WriteLine($"   - {method.Name}({parameters})");
        }

        Console.WriteLine(" - Properties:");
        var properties = interfaceType
            .GetProperties()
            .OrderBy(p => p.Name)
            .ToList();

        foreach (var prop in properties)
        {
            Console.WriteLine($"   - {prop.Name} : {prop.PropertyType.Name}");
        }
    }

    // Abstraction: abstract classes
    public static void PrintIsAbstractClass(Type clsType)
    {
        Console.WriteLine($"{clsType.Name} cannot be instantiated: "
            + (clsType.IsAbstract && !clsType.IsInterface));
    }

    public static void PrintIsAbstractMethod(Type clsType, string methodName, Type[] parameterTypes)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            PrintMethodNotFoundInClass(clsType, methodName, parameterTypes);
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) method {methodName} has no implementation: {method.IsAbstract}");
    }

    // Generics

    public static void PrintFieldType(Type clsType, string fieldName)
    {
        var field = clsType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static);

        if (field == null)
        {
            PrintFieldNotFoundInClass(clsType, fieldName);
            return;
        }

        Type fieldType = field.FieldType;
        Console.WriteLine($"Field: {fieldName}, Type: {GetFriendlyTypeName(fieldType)}");
    }

    public static void PrintGenericClassConstraints(Type clsType)
    {
        if (!clsType.IsGenericTypeDefinition)
        {
            Console.WriteLine($"Class '{clsType.Name}' is not a generic type definition.");
            return;
        }

        Console.WriteLine($"Inspecting generic constraints for Class '{GetFriendlyTypeName(clsType)}':");

        var genericArgs = clsType.GetGenericArguments();
        foreach (var arg in genericArgs)
        {
            Console.WriteLine($" - Generic parameter: {arg.Name}");

            var constraints = arg.GetGenericParameterConstraints()
                                 .Where(c => c.IsInterface)
                                 .OrderBy(c => c.Name)
                                 .ToList();

            if (constraints.Count == 0)
            {
                Console.WriteLine("  (No interface constraints)");
            }
            else
            {
                Console.WriteLine("  Must implement:");
                foreach (var c in constraints)
                {
                    Console.WriteLine($"    - {GetFriendlyTypeName(c)}");
                }
            }
        }
    }


    public static void PrintGenericMethodConstraints(Type clsType, string methodName, Type[] parameterTypes)
    {
        var methods = clsType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
            .ToList();

        var method = methods.FirstOrDefault(m =>
        {
            var parameters = m.GetParameters();
            if (parameters.Length != parameterTypes.Length)
                return false;

            for (int i = 0; i < parameters.Length; i++)
            {
                var methodParamType = parameters[i].ParameterType;
                var testParamType = parameterTypes[i];

                if (methodParamType.IsGenericParameter)
                    continue;

                if (methodParamType != testParamType)
                    return false;
            }

            return true;
        });

        if (method == null)
        {
            Console.WriteLine($"(Class {clsType.Name}) Generic method '{methodName}' with the given parameter types was not found.");
            return;
        }

        Console.WriteLine($"(Class {clsType.Name}) generic method '{method.Name}' found. Inspecting constraints:");

        foreach (var arg in method.GetGenericArguments())
        {
            Console.WriteLine($"- Generic parameter: {arg.Name}");

            var constraints = arg.GetGenericParameterConstraints()
                                 .Where(c => c.IsInterface)
                                 .OrderBy(c => c.Name)
                                 .ToList();

            if (constraints.Count == 0)
            {
                Console.WriteLine("  (No interface constraints)");
            }
            else
            {
                Console.WriteLine("  Must implement:");
                foreach (var c in constraints)
                {
                    Console.WriteLine($"    - {c.Name}");
                }
            }
        }
    }


    // Helper methods
    private static void PrintFieldNotFoundInClass(Type clsType, string fieldName)
    {
        Console.WriteLine($"(Class {clsType.Name}) field {fieldName} not found. (Are you sure it is a field and not a property?)");
    }

    private static void PrintPropertyNotFoundInClass(Type clsType, string propertyName)
    {
        Console.WriteLine($"(Class {clsType.Name}) property {propertyName} not found. (Are you sure it is a property and not a field?)");
    }

    private static void PrintMethodNotFoundInClass(Type clsType, string methodName, Type[] parameterTypes)
    {
        string parameters = string.Join(", ", parameterTypes.Select(t => t.Name));
        Console.WriteLine($"(Class {clsType.Name}) method {methodName}({parameters}) not found");
    }

    private static MethodInfo? GetFirstAvailableAccessor(PropertyInfo property)
    {
        return property.GetGetMethod() ?? property.GetSetMethod();
    }

    // enum
    public static void PrintAllEnumValues<T>() where T : Enum
    {
        List<T> values = [.. Enum.GetValues(typeof(T)).Cast<T>()];

        Console.WriteLine($"Printing all values of (enum)eration {typeof(T).Name}:");
        foreach (T value in values)
        {
            int numericValue = Convert.ToInt32(value);
            Console.WriteLine($" - {value} ({numericValue})");
        }
    }

    // Recursion

    public static void PrintIsRecursive(Type clsType, string methodName, Type[] parameterTypes)
    {
        var method = clsType.GetMethod(methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            Console.WriteLine($"Class {clsType.Name}: method {methodName}({string.Join(", ", parameterTypes.Select(GetFriendlyTypeName))}) not found");
            return;
        }

        string methodSignature = GetMethodSignature(method);
        Console.WriteLine($"{methodSignature} is recursive: {IsRecursive(method)}");
    }

    private static bool IsRecursive(MethodInfo method)
    {
        MethodBody body = method.GetMethodBody() ?? throw new ArgumentException(method.Name, "Unexpected args value: {methodName}");

        var ilBytes = body.GetILAsByteArray();
        if (ilBytes == null) { return false; }

        int methodMetadataToken = method.MetadataToken;

        for (int i = 0; i < ilBytes.Length - 4; i++)
        {
            if (ilBytes[i] == 0x28)
            {
                int calledMethodToken = BitConverter.ToInt32(ilBytes, i + 1);

                if (calledMethodToken == methodMetadataToken)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static void VerifyMethodBodyUnchanged(Type clsType, string methodName, Type[] parameterTypes, string expectedBase64)
    {
        var method = clsType.GetMethod(
            methodName,
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static,
            null, parameterTypes, null);

        if (method == null)
        {
            Console.WriteLine($"Class {clsType.Name}: method {methodName}({string.Join(", ", parameterTypes.Select(GetFriendlyTypeName))}) not found");
            return;
        }

        var ilBytes = method?.GetMethodBody()?.GetILAsByteArray();

        if (ilBytes == null)
        {
            Console.WriteLine($"Could not read method body: {clsType.Name}.{methodName}");
            return;
        }

        var actualBase64 = Convert.ToBase64String(ilBytes);

        var friendlyParams = string.Join(", ", method!.GetParameters().Select(p => GetFriendlyTypeName(p.ParameterType)));
        string methodSignature = GetMethodSignature(method);

        if (actualBase64 == expectedBase64)
        {
            Console.WriteLine($"{methodSignature} body is unchanged.");
        }
        else
        {
            Console.WriteLine($"{methodSignature} body is changed.");
            Console.WriteLine($"Expected base64: {expectedBase64}");
            Console.WriteLine($"Actual base64:   {actualBase64}");
        }
    }

    private static string GetMethodSignature(MethodInfo method)
    {
        var friendlyParams = string.Join(", ", method!.GetParameters().Select(p => GetFriendlyTypeName(p.ParameterType)));
        return $"{method.Name}({friendlyParams})";
    }
}