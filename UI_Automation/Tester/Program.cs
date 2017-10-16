using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {

            string x = Console.ReadLine();

            if (!x.Equals("start")) return;

            AutomationElement rootElement = AutomationElement.RootElement;

            Condition condition = new PropertyCondition(AutomationElement.NameProperty, "MainWindow");
            AutomationElement appElement = rootElement.FindFirst(TreeScope.Children, condition);

            if (appElement == null) return;

            AutomationElement txtElementA = GetElement(appElement, "numA");
            AutomationElement txtElementB = GetElement(appElement, "numB");
            AutomationElement sumButton = GetElement(appElement, "sumBtn");


            ValuePattern valuePatternA = txtElementA.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            ValuePattern valuePatternB = txtElementB.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            InvokePattern invokePatternBtn = sumButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;


            valuePatternA.SetValue(".");
            valuePatternB.SetValue("1");

            invokePatternBtn.Invoke();

        }

        private static AutomationElement GetElement(AutomationElement parentElement, string value)
        {
            Condition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, value);
            AutomationElement txtElement = parentElement.FindFirst(TreeScope.Descendants, condition);

            return txtElement;
        }

    }
}
