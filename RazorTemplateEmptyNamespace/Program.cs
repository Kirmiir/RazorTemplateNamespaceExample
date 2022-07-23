using RazorEngineCore;

public class TestModelWithoutNamespace
{
    public string Name { get; set; }
    public int[] Items { get; set; }
}

public class Program
{
	public static void Main()
	{

        Example1();
        Example2();
    }

    private static void Example1()
    {
        IRazorEngine razorEngine = new RazorEngine();
        string content = "Hello @Model.Name";
        IRazorEngineCompiledTemplate<RazorEngineTemplateBase<TestModelWithoutNamespace>> template = razorEngine.Compile<RazorEngineTemplateBase<TestModelWithoutNamespace>>(content);

        string result = template.Run(instance =>
        {
            instance.Model = new TestModelWithoutNamespace()
            {
                Name = "Hello",
                Items = new[] { 3, 1, 2 }
            };
        });

        Console.WriteLine(result);

    }

    private static void Example2()
    {
        IRazorEngine razorEngine = new RazorEngine();
        string content = "Hello @Model.Name";

        IRazorEngineCompiledTemplate<RazorEngineTemplateBase<RazorTemplateEmptyNamespace.TestModel.TestModelInnerClass>> template2 = razorEngine.Compile<RazorEngineTemplateBase<RazorTemplateEmptyNamespace.TestModel.TestModelInnerClass>>(content);

        string result2 = template2.Run(instance =>
        {
            instance.Model = new RazorTemplateEmptyNamespace.TestModel.TestModelInnerClass()
            {
                Name = "Hello",
                Items = new[] { 3, 1, 2 }
            };
        });

        Console.WriteLine(result2);

    }
}
