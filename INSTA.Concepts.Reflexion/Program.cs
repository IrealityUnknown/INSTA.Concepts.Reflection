using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSTA.Concepts.Reflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test_Blab();

            Test_GetProperty();
        }

        private static void Test_Blab()
        {
            Type type = typeof (StringBuilder);

            // On fait imprimer la liste de toutes les méthodes
            // de l'objet Type en cours
            Console.WriteLine("##### Methods ##### {0}", "\r\n");
            foreach (var m in type.GetMethods())
            {
                Console.WriteLine(m.Name);
            }
            Console.WriteLine();

            // On fait imprimer la liste de toutes les méthodes
            // de l'objet Type en cours
            Console.WriteLine("##### Contructors ##### {0}", "\r\n");
            foreach (var m in type.GetConstructors())
            {
                Console.WriteLine(m.Name);
                foreach (var param in m.GetParameters())
                {
                    Console.WriteLine("\t({1} : {2})", m.Name, param.ParameterType.Name, param.Name);
                }
            }
            Console.WriteLine();

            // On fait imprimer la liste de toutes les propriétés
            // de l'objet Type en cours
            Console.WriteLine("##### Properties ##### {0}", "\r\n");

            foreach (var m in type.GetProperties())
            {
                Console.WriteLine("{0} : {1}", m.Name, m.PropertyType.Name);
            }
            Console.WriteLine();
        }


        public static void Test_GetProperty()
        {
            var p = new Person() {Id = 15};

            var result = (int) ReflectionHelper.GetPropertyValue(p, "Id");

            Console.WriteLine("The Id of the Person : {0}", result);
        }
    }

}
