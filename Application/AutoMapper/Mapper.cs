using AutoMapper;
using Framework.Command;
using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public static class Mapper<TEntity, TCommand>
       where TEntity : BaseEntity
       where TCommand : CommandBase
    {
        public static TEntity CommandToEntity(TCommand command)
        {
            var config = new MapperConfiguration(conf => conf.CreateMap<TCommand, TEntity>());
            var mapper = config.CreateMapper();
            return mapper.Map<TEntity>(command);
        }
        public static TCommand EntityToCommand(TEntity entity)
        {
            var config = new MapperConfiguration(conf => conf.CreateMap<TEntity, TCommand>());
            var mapper = config.CreateMapper();
            return mapper.Map<TCommand>(entity);
        }
    }
}
