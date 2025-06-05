using Shopping.DAL.Entities;
using System.Data;

namespace Shopping.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
                _context = context;
        }

        public async Task SeederAsync() 
        {
            //metodo q sustituye update-database, crea la bd inmediatamente cuando se hace la api

            await _context.Database.EnsureCreatedAsync();

            //metodos para prepoblar la bd

            await PopulateCountriesAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methods

        private async Task PopulateCountriesAsync() 
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }

                });

                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos aires"
                        },
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cordoba"
                        }
                    }

                });

            }
        }

        #endregion


    }
}
