using DominioTesteViajaNet.Interfaces.Repositorios;
using DominioTesteViajaNet.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTesteViajaNet.Servicos
{
    public class BaseServico<TEntity> : IDisposable, IBaseServico<TEntity> where TEntity : class
    {
        private readonly IBaseRepositorio<TEntity> _repositorio;

        public BaseServico(IBaseRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Add(TEntity obj)
        {
            _repositorio.Add(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositorio.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repositorio.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _repositorio.Update(obj);
        }
    }
}
