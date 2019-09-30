using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Repositories;
using QuestRoomCatalog.DataLayer;

namespace QuestRoomCatalog.DataLayer.UnitOfWork
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T: class
    {
        private Model1 db;
        private bool disposed = false;
        Repository<T> _genericRepository;

        public UnitOfWork()
        {
            db = new Model1();
        }


        //public Repository<Authors> AuthorUowRepository
        //{
        //    get
        //    {

        //        if (this._authorUowRepository == null)
        //            _authorUowRepository = new Repository<Authors>(db);
        //        return _authorUowRepository;
        //    }
        //}

        //public Repository<Books> BookUowRepository
        //{
        //    get
        //    {
        //        if (this._bookUowRepository == null)
        //            _bookUowRepository = new Repository<Books>(db);
        //        return _bookUowRepository;
        //    }
        //}

        //public Repository<User> UserUowRepository
        //{
        //    get
        //    {
        //        if (this._userUowRepository == null)
        //            _userUowRepository = new Repository<User>(db);
        //        return _userUowRepository;
        //    }
        //}

        //public Repository<Rent> RentUowRepository
        //{
        //    get
        //    {
                
        //        if (this._rentUowRepository == null)
        //            _rentUowRepository = new Repository<Rent>(db);
        //        return _rentUowRepository;
        //    }
        //}

        //public Repository<Genre> GenreUowRepository
        //{
        //    get
        //    {

        //        if (this._genreUowRepository == null)
        //            _genreUowRepository = new Repository<Genre>(db);
        //        return _genreUowRepository;
        //    }
        //}

        public Repository<T> GenericUowRepository
        {
            get
            {
                if (this._genericRepository == null)
                    _genericRepository = new Repository<T>(db);
                return _genericRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}