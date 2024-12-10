using IngatlanEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanEF.Services
{
    internal class UgyintezoService
    {
        public static List<Ugyintezo> GetAllUgyintezo()
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    List<Ugyintezo> result = context.Ugyintezos.ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    List<Ugyintezo> hibaLista = new List<Ugyintezo>();
                    hibaLista.Add(new Ugyintezo()
                    {
                        Id = -1,
                        Nev = ex.Message
                    });
                    return hibaLista;
                }
            }
        }


        
    }
}
