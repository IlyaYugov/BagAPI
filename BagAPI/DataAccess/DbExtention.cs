using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public static class DbExtention
    {
        public static void Save(this DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: Здесь должна юыть обработка ошибок
            }
        }
    }
}
