namespace fae.app
{
    public class Runner
    {
        public async Task<string> Run()
        {
            await Task.Delay(5000);
            return "OK";
        }
    }
}