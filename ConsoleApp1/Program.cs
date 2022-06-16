using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Enablon.ProductModel;
using log4net.Config;
using log4net;
using System.Collections.Generic;

namespace ConsoleApp1
{

    public class Program : Todolist
    {
        
        private static IWebElement selectRecordCheckbox;   
                
        public static void Main()
        {
            WebDriver driver = new ChromeDriver();
          
            driver.Navigate().GoToUrl("https://todomvc.com/examples/angular2/");
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(5000);


            //Configure Log4net
            BasicConfigurator.Configure();
            //Create a logger
            ILog logger = LogManager.GetLogger(typeof(Program));
            //Writer logs in our test

            System.Threading.Thread.Sleep(5000);

            Testcase01_AddRecordTodoList(driver);
            logger.Debug("Records are added in the Grid");

            Testcase02_CheckOutRecordFromTodoList(driver);
            logger.Debug("On Selecting record the record gets checkedout in the Grid");
            selectRecordCheckbox = driver.FindElement(By.XPath("//input[@class='toggle']"));

            Testcase03_VerifyClearCompletedButtonIsEnabled(driver, selectRecordCheckbox);
            logger.Debug("on selecting any record the clearcompletedbutton gets enabled");

            Testcase04_RemoveRecordByClickingCrossButton(driver);
            logger.Debug("On Clicking X button on the record hove or select , the record gets removed");

            Testcase05_VerifyTheRemovedDataDoesNotExistInGridAnyMore(driver);
            logger.Debug("Once the data is removed, verify that same data still exist");

        }

        public static void Testcase01_AddRecordTodoList(WebDriver driver)
        {
            Todolist todoList1 = new Todolist();
            todoList1.AddRecord(driver);
           
        }
        public static void Testcase02_CheckOutRecordFromTodoList(WebDriver driver)
        {
            Todolist todoList2 = new Todolist();
            todoList2.CheckOutRecordFromGrid(driver);
        }

        public static void Testcase03_VerifyClearCompletedButtonIsEnabled(WebDriver driver, IWebElement selectRecordCheckbox)
        {
            Todolist todoList3 = new Todolist();
            todoList3.VerifyClearCompletedButtonIsEnabled(driver, selectRecordCheckbox);
                
        }

        public static void Testcase04_RemoveRecordByClickingCrossButton(WebDriver driver)
        {    
            Todolist todoList3 = new Todolist();
            todoList3.RemoveRecordByClickingXButton(driver);
        }

        public static void Testcase05_VerifyTheRemovedDataDoesNotExistInGridAnyMore(WebDriver record)
        {
            Todolist todoList3 = new Todolist();
            todoList3.VerifyDeletedRecordDoesNotDisplayInTheGrid(record);

        }
        
        

    }
}