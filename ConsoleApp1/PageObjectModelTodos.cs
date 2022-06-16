/* ***************************************************************
* 
* Author: Palak Joshi
* Date: June 09, 2022
* Changes
* Date Description Author
* <09-June-2021> <Initial file creation> <Palak Joshi>
*****************************************************************/


using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Enablon.ProductModel
{
    public class Todolist
    {
        #region Methods

        /// <summary>
        /// Add record in the grid
        /// /// </summary> 
        /// <param name="driver">Report name to be search</param>
        public bool AddRecord(WebDriver driver)
        {
          
            IWebElement record = driver.FindElement(By.XPath("//input[@placeholder='What needs to be done?']"));
           
            record.SendKeys("Palak111");
            record.SendKeys(Keys.Enter);

            record.SendKeys("Palak112");
            record.SendKeys(Keys.Enter);

            record.SendKeys("Palak");
            record.SendKeys(Keys.Enter);
        
            return true;
        }
        /// <summary>
        /// Select or check out the record from the grid
        /// /// </summary> 
        /// <param name="driver">Report name to be search</param>
        public bool CheckOutRecordFromGrid(WebDriver driver)
        {
            IWebElement selectRecordCheckbox = driver.FindElement(By.XPath("//input[@class='toggle']"));
            selectRecordCheckbox.Click();
            VerifyClearCompletedButtonIsEnabled(driver ,selectRecordCheckbox);
            return true;
        }

        /// <summary>
        /// Remove record from grid by clicking X button on the right side of button. 
        /// /// </summary> 
        /// <param name="driver">Report name to be search</param>
        public bool RemoveRecordByClickingXButton(WebDriver driver)
        {
            IWebElement xButton = driver.FindElement(By.XPath("//button[@class='destroy']"));   //button[@class='destroy']
            xButton.Click();
            return true;
        }
        /// <summary>
        /// Verify Clear completed button is enabled once any record is checkedout or selected
        /// /// </summary> 
        /// <param name="driver, selectrechordCheckbox">Report name to be search</param>
        public void VerifyClearCompletedButtonIsEnabled(WebDriver driver, IWebElement selectRecordCheckbox)
        {
            if (selectRecordCheckbox.Selected)
            {
                IWebElement btnClearCompleted = driver.FindElement(By.XPath("//button[text() = 'Clear completed']"));
                Console.WriteLine("Clear button enabled : {0} ", btnClearCompleted.Enabled ? "T" : "F");
                if (btnClearCompleted.Enabled)
                {
                    int count = 0;
                    count++;
                }
                else
                {
                }

            }
        }

        /// <summary>
        /// Search record which is deleted still exist in the list 
        /// /// </summary> 
        /// <param name="Recordname">Report name to be search</param>
        public bool VerifyDeletedRecordDoesNotDisplayInTheGrid(WebDriver record)
            {                  

            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(record.FindElements(By.XPath("//label[text()='Palak112']")));
            int cnt = elementList.Count;
            RemoveRecordByClickingXButton(record);
            try
            {
                bool isElementDisplayed = record.FindElement(By.XPath("//label[text()='Palak112']")).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No record exist...Record is deleted");
            }
                        
            return true;
        }
                     

     }
             #endregion

        public class RecordVO
        {
            public string Recordname { get; set; }

        }
    
       
    
}
