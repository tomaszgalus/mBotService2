using System;
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

        // Production
        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Please specify the query :)."); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("Hello")]
        public async Task HelloIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Hello Dominik");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Payroll")]
        public async Task PayrollIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"John 1000 EUR, Maggie 1100 EUR, Steve 1200 EUR");
            context.Wait(MessageReceived);
        }

        [LuisIntent("AcceptAll")]
        public async Task AcceptAllIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"All transaction has been accepted");
            context.Wait(MessageReceived);
        }

        [LuisIntent("RejectAll")]
        public async Task RejectAllIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"All transaction has been rejected");
            context.Wait(MessageReceived);
        }
         // end production
           
    }
}