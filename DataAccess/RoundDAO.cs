﻿using ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoundDAO
    {
        private static RoundDAO instance = null;
        private static readonly object Lock = new object();
        public static RoundDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new RoundDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Round> GetRounds()
        {
            using var context = new PetroleumBusinessDBContext();
            var list = context.Rounds.ToList();
            return list;
        }
        public Round GetRoundById(int id)
        {
            using var context = new PetroleumBusinessDBContext();
            var check = context.Rounds.FirstOrDefault(r => r.RoundID == id);
            if (check != null)
            {
                return check;
            }
            throw new ArgumentException("Round not found!");
        }
        public void InsertRound(Round round)
        {
            using var context = new PetroleumBusinessDBContext();
            try
            {
                context.Add(round);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateRound(Round round)
        {
            using var context = new PetroleumBusinessDBContext();
            try
            {
                context.Entry<Round>(round).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteRound(int id)
        {
            using var context = new PetroleumBusinessDBContext();
            var check = GetRoundById(id);
            try
            {
                context.Remove(check);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}