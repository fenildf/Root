using System;
using System.Collections.Generic;
using System.Data.Entity;
using Hangerd.EntityFramework;
using Root.Domain.Repositories;
using Root.Infrastructure.EF.ModelConfigurations;
using Root.Infrastructure.EF.Repositories;

namespace Root.Infrastructure.EF
{
	public class RootDbContext : EfRepositoryContext, IRootDbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations
				.Add(new MorphemeConfig())
				.Add(new WordConfig())
				.Add(new WordMorphemeConfig())
				.Add(new WordInterpretationConfig());

			base.OnModelCreating(modelBuilder);
		}

		private static readonly Dictionary<Type, Type> RepositoryTypes = new Dictionary<Type, Type>
		{
			{ typeof (IMorphemeRepository), typeof (MorphemeRepository) },
			{ typeof (IWordRepository), typeof (WordRepository) }
		};

		public TRepository GetRepository<TRepository>()
		{
			var repositoryType = typeof (TRepository);

			if (!RepositoryTypes.ContainsKey(repositoryType))
				throw new Exception("Unknow repository type");

			return (TRepository) Activator.CreateInstance(RepositoryTypes[repositoryType], this);
		}
	}
}
