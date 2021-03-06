﻿using AngleSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Mocks;

namespace UnitTests
{
    [TestClass]
    public class ReflectionResolverTests
    {
        MockReflectionResolver mockResolver;
        MockService mockService;
        List<MockService> mockServices;
        IDependencyResolver originalResolver;

        private void CreateResolver()
        {
            mockService = new MockService();
            mockServices = new List<MockService> { mockService };

            mockResolver = new MockReflectionResolver();
            mockResolver.GetInstanceDelegate = () => mockService;
            mockResolver.GetAllInstancesDelegate = () => mockServices;
        }

        [TestInitialize]
        public void SetUp()
        {
            originalResolver = DependencyResolver.Current;
            CreateResolver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DependencyResolver.SetResolver(originalResolver);
        }

        [TestMethod]
        public void SetsInternalResolver()
        {
            // Act
            DependencyResolver.SetResolver(mockResolver);

            // Assert
            Assert.IsNotNull(DependencyResolver.Current);
            Assert.IsNotInstanceOfType(DependencyResolver.Current, typeof(MockReflectionResolver));
        }

        [TestMethod]
        public void GetServiceReturnsService()
        {
            // Arrange
            DependencyResolver.SetResolver(mockResolver);
            var service = DependencyResolver.Current.GetService<MockService>();

            // Assert
            Assert.AreEqual(mockService, service);
        }

        [TestMethod]
        public void GetServicesReturnsServices()
        {
            // Arrange
            DependencyResolver.SetResolver(mockResolver);
            var services = DependencyResolver.Current.GetServices<MockService>();

            // Assert
            Assert.AreEqual(1, services.Count());
            Assert.AreEqual(mockService, services.FirstOrDefault());
        }
    }
}
