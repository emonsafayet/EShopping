using Catalog.Application.Mappers;
using Catalog.Core.Repositories;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesQuery
    {
        private readonly ITypesRepository _typesRepository;

        public GetAllTypesQuery(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public async Task<IList<ITypesRepository>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typeList = await _typesRepository.GetAllTypes();
            var typeResponseList = ProductMapper.Mapper.Map<IList<ITypesRepository>>(typeList);
            return typeResponseList;
        }
    }
}
