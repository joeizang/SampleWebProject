using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleWebProject.Abstractions;
using SampleWebProject.Controllers;
using SampleWebProject.Models;

namespace SampleWebProjectTests
{
    [TestClass]
    public class PublisherControllerTest
    {
        [TestMethod]
        public void IndexActionReturnsListofPublishers()
        {
            var repository = new FakeRepository<Publisher>();

            

            var controller = new PublishersController(repository);

            var controller1 = new PublishersController(new ApplicationDbContext());

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Publisher>));
        }
    }

    public class FakeRepository<T> : IRepo<T> where T : class
    {
        public IList<T> Set { get; set; }

        public FakeRepository()
        {
            Set = new List<T>();
        }

        public void Add(T entity)
        {
            
        }

        public void AddRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            return Set;
        }

        public IList<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
