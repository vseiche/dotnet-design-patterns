namespace DesignPatterns.Net.Console
{
    public class BasicCommand : IBasicCommand
    {
        private readonly IMainService mainService;

        public BasicCommand(IMainService mainService)
        {
            this.mainService = mainService;
        }

        public void Execute()
        {
            var testInstance = mainService.GetTest();
            if (testInstance != null)
            {
                testInstance.DoSomething();
            }
        }
    }
}
