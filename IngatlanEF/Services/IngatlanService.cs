﻿using IngatlanEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanEF.Services
{
    internal class IngatlanService
    {
        public static List<Ingatlan> GetAllIngatlan()
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    List<Ingatlan> result = context.Ingatlans.ToList();
                    return result;
                }
                catch (Exception ex)
                {
                    List<Ingatlan> hibaLista = new List<Ingatlan>();
                    hibaLista.Add(new Ingatlan()
                    {
                        Id = -1,
                        Telepules = ex.Message
                    });
                    return hibaLista;
                }
            }
        }
    }
}
