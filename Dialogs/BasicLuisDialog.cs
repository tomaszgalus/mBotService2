using System;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : 
        base(new LuisService(new LuisModelAttribute(ConfigurationManager.AppSettings["LuisAppId"], 
                             ConfigurationManager.AppSettings["LuisAPIKey"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Please specify the query :).");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hello")]
        public async Task HelloIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Hello Dominik. Nice to hear you again. What do you want to do?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AccountBalance")]
        public async Task AccountBalanceIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Which account do you mean?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AllAcountsBalance")]
        public async Task AllAcountsBalanceIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("123456000 - 104 000 EUR");
            sb.AppendLine("234567000 - 235 000 USD");
            sb.AppendLine("456789000 - 453 000 EUR");
            sb.AppendLine("Totatl blance is 559 000 EUR and 235 000 USD.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Payments")]
        public async Task PaymentsIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("150 000 EUR for UPS Invoice 45 / 2017");
            sb.AppendLine("217 000EUR for Innogy Invoice 12 / 2017");
            sb.AppendLine("3 400 EUR for T mobile Telephone bill september - 2017");
            sb.AppendLine("Do you want to accept these payments?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("AcceptAll")]
        public async Task AcceptAllIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("All transaction has been accepted.");
            sb.AppendLine("I want to remind you that your card expires next month. Do you want to renew it or would you like a new Visa Bussines Gold with 50000 EUR limit.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Visa")]
        public async Task VisaIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ok. By the way please note that tomorrow you need to pay taxes. Do you want do it now?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("Goodbye")]
        public async Task GoodbyeIntent(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Goodbye, Dominik.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }
    }
}