class GradeFormDouble : GradeForm<double> {
    public GradeFormDouble(double grade) : base(grade) { }

    public override bool IsPass() => Grade >= 5.5;
}