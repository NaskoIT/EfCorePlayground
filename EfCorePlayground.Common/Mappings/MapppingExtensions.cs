using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace EfCorePlayground.Common.Mappings
{
    public static class MappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo(membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(parameters);
        }

        public static Destination To<Destination>(this object source) => Mapper.Map<Destination>(source);

        public static Destination To<Destination>(this object source, object destination) =>
            (Destination)Mapper.Map(source, destination, source.GetType(), destination.GetType());

        public static Destination To<Source, Destination>(this Source source, Destination destination, Action<IMappingOperationOptions<Source, Destination>> options) =>
           Mapper.Map(source, destination, options);

        public static IEnumerable<TDestination> MapCollection<TDestination>(this IEnumerable enumerable)
            => Mapper.Map<IEnumerable<TDestination>>(enumerable);

        public static async Task<IEnumerable<TDestination>> MapCollection<TDestination>(this Task task)
        {
            var taskWithResult = task as dynamic;

            if (!task.HasEnumerableResult())
            {
                dynamic destination = Mapper.Map<TDestination>(await taskWithResult);
                return new List<TDestination> { destination };
            }

            return Mapper.Map<IEnumerable<TDestination>>(await taskWithResult);
        }

        private static bool HasEnumerableResult(this Task task)
        {
            Type type = task.GetType();
            if (!type.IsGenericType)
            {
                throw new InvalidOperationException("Cannot map a void Task.");
            }

            Type[] genericArguments = type.GetGenericArguments();

            return typeof(IEnumerable).IsAssignableFrom(genericArguments.First());
        }
    }
}
