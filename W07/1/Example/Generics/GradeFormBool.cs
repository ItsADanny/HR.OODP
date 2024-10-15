class GradeFormBool : GradeForm<bool> {
    public GradeFormBool(bool grade) : base(grade) { }

    public override bool IsPass() => Grade;
}