using Autofac;
using ECommerceWinForms;
using System;
using System.Windows.Forms;

namespace ECommerceWinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
           System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            using (var container = AutofacConfig.Configure())
            using (var scope = container.BeginLifetimeScope())
            {
                var loginForm = scope.Resolve<LoginForm>(); // Autofac injects ILifetimeScope
               System.Windows.Forms.Application.Run(loginForm);
            }
        }
    }
}