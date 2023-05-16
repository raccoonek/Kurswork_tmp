using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Text.Json;
using System.Xml.Serialization;

namespace Kurswork
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Flowchart_main_form flowchart_Main_Form = new Flowchart_main_form();
            Application.Run(flowchart_Main_Form);


            //string bd_json;
            //XmlSerializer xml_serializer =new XmlSerializer(typeof(Flowchart_main_form));
            //using (StringWriter string_writer = new StringWriter())
            //{
            //    // Сериализация.
            //    xml_serializer.Serialize(string_writer, flowchart_Main_Form);

            //    // Отображение сериализации.
            //    bd_json = string_writer.ToString();

            //}

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    FlowChart flowChart = new FlowChart
            //    {
            //        Name = "New",
            //        Jsonstring = bd_json
            //    };

            //    // добавляем их в бд
            //    db.FlowChart.Add(flowChart);

            //    db.SaveChanges();
            //}

            //BinaryFormatter formatter = new BinaryFormatter();
            //// получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("new.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, flowchart_Main_Form);

            //}
        }
        
    }
}