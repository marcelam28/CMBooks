﻿using System.Collections.Generic;
using CMBooks.BusinessLogic.Workflow.Interfaces;
using Deventure.Common.Interfaces;
using Deventure.DataLayer.Interfaces;

namespace Deventure.BusinessLogic.TypeManagement
{
    public static class DataAdapterExtensions
    {
        public static IMapperService MapperService { get; set; }

        #region IModel

        /// <summary>
        ///     Copies the object to a new entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
        /// </summary>
        /// <typeparam name="TDestType">The type of returned entity</typeparam>
        /// <param name="entity">The entity that will be copied to the new type</param>
        /// <returns>An entity of type <typeparamref name="TDestType" /> that contains all the properties from the source object</returns>
        public static TDestType CopyTo<TDestType>(this IModel entity) where TDestType : class
        {
            return entity != null ? MapperService.CopyTo<TDestType>(entity) : null;
        }

        /// <summary>
        ///     Copies the object to an existing entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
        /// </summary>
        /// <typeparam name="TDestType">The type of destination entity</typeparam>
        /// <param name="entity">The entity that will be copied</param>
        /// <param name="destination">The entity that will be modified</param>
        public static void CopyTo<TDestType>(this IModel entity, TDestType destination) where TDestType : class
        {
            if (entity == null)
            {
                return;
            }

            MapperService.CopyTo(entity, destination);
        }

        /// <summary>
        ///     Copies the list of objects to a new list with entities of type <typeparamref name="TDestType" /> by mapping their
        ///     properties one-to-one,
        ///     in the same order as found in the source list
        /// </summary>
        /// <typeparam name="TDestType">The type of the entities in the returned list</typeparam>
        /// <param name="entityList">The list of entities that will be copied to the new type</param>
        /// <returns>
        ///     A list with entities of type <typeparamref name="TDestType" /> that contain all the properties from the source
        ///     objects
        /// </returns>
        public static IList<TDestType> CopyTo<TDestType>(this IEnumerable<IModel> entityList) where TDestType : class
        {
            return entityList != null ? MapperService.CopyTo<TDestType>(entityList) : null;
        }

        #endregion

        #region IDataAccessObject

        /// <summary>
        ///     Copies the object to a new entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
        /// </summary>
        /// <typeparam name="TDestType">The type of returned entity</typeparam>
        /// <param name="entity">The entity that will be copied to the new type</param>
        /// <returns>An entity of type <typeparamref name="TDestType" /> that contains all the properties from the source object</returns>
        public static TDestType CopyTo<TDestType>(this IDataAccessObject entity) where TDestType : class
        {
            return entity != null ? MapperService.CopyTo<TDestType>(entity) : null;
        }

        /// <summary>
        ///     Copies the object to an existing entity of type <typeparamref name="TDestType" /> by mapping their properties one-to-one
        /// </summary>
        /// <typeparam name="TDestType">The type of destination entity</typeparam>
        /// <param name="entity">The entity that will be copied</param>
        /// <param name="destination">The entity that will be modified</param>
        public static void CopyTo<TDestType>(this IDataAccessObject entity, TDestType destination) where TDestType : class
        {
            if (entity == null)
            {
                return;
            }

            MapperService.CopyTo(entity, destination);
        }

        /// <summary>
        ///     Copies the list of objects to a new list with entities of type <typeparamref name="TDestType" /> by mapping their
        ///     properties one-to-one,
        ///     in the same order as found in the source list
        /// </summary>
        /// <typeparam name="TDestType">The type of the entities in the returned list</typeparam>
        /// <param name="entityList">The list of entities that will be copied to the new type</param>
        /// <returns>
        ///     A list with entities of type <typeparamref name="TDestType" /> that contain all the properties from the source
        ///     objects
        /// </returns>
        public static IList<TDestType> CopyTo<TDestType>(this IEnumerable<IDataAccessObject> entityList) where TDestType : class
        {
            return entityList != null ? MapperService.CopyTo<TDestType>(entityList) : null;
        }

        #endregion
    }
}