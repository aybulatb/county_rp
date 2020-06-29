using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class FactionAdapter : IFactionAdapter
    {
        private Extra.FactionClient _factionClient;

        public FactionAdapter(Extra.FactionClient factionClient)
        {
            _factionClient = factionClient;
        }

        public async Task<Faction> Create(Faction faction)
        {
            Extra.Faction factionExt = new Extra.Faction
            {
                Id = faction.Id,
                Name = faction.Name,
                Ranks = faction.Ranks,
                Type = (Extra.FactionType)faction.Type
            };

            try
            {
                factionExt = await _factionClient.CreateAsync(factionExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Faction
            {
                Id = factionExt.Id,
                Name = factionExt.Name,
                Ranks = factionExt.Ranks.ToArray(),
                Type = (FactionType)factionExt.Type
            };
        }

        public async Task<Faction> GetById(string id)
        {
            Extra.Faction factionExt;

            try
            {
                factionExt = await _factionClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Faction
            {
                Id = factionExt.Id,
                Name = factionExt.Name,
                Ranks = factionExt.Ranks.ToArray(),
                Type = (FactionType)factionExt.Type
            };
        }

        public async Task<Faction> Edit(string id, Faction faction)
        {
            var factionExt = new Extra.Faction
            {
                Id = faction.Id,
                Name = faction.Name,
                Ranks = faction.Ranks,
                Type = (Extra.FactionType)faction.Type
            };

            try
            {
                factionExt = await _factionClient.EditAsync(id, factionExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Faction
            {
                Id = factionExt.Id,
                Name = factionExt.Name,
                Ranks = factionExt.Ranks.ToArray(),
                Type = (FactionType)factionExt.Type
            };
        }

        public async Task Delete(string id)
        {
            try
            {
                await _factionClient.DeleteAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }
        }

        public async Task<FilteredModels<Faction>> FilterBy(int page, int count, string id, string name)
        {
            Extra.FilteredModelsOfFaction filteredFactionsExt;

            try
            {
                filteredFactionsExt = await _factionClient.FilterByAsync(page, count, id, name);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<Faction>
            {
                Items = filteredFactionsExt.Items.Select(f => new Faction
                {
                    Id = f.Id,
                    Name = f.Name,
                    Ranks = f.Ranks.ToArray(),
                    Type = (FactionType)f.Type
                }).ToList(),
                AllAmount = filteredFactionsExt.AllAmount,
                Page = filteredFactionsExt.Page,
                MaxPage = filteredFactionsExt.MaxPage
            };
        }
    }
}
