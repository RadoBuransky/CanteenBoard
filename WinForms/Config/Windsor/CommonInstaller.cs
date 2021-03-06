﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Facilities.Logging;
using CanteenBoard.Core;
using CanteenBoard.Core.Processors;
using CanteenBoard.Repositories;
using CanteenBoard.Repositories.Impl;
using System.Configuration;
using CanteenBoard.Entities.Boards;
using CanteenBoard.WinForms.BoardTemplates;
using Castle.MicroKernel;
using System.Collections;

namespace CanteenBoard.WinForms.Config.Windsor
{
    /// <summary>
    /// Logger installer
    /// </summary>
    public class CommonInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            container.Register(
                Component.For<IRepository>()
                    .ImplementedBy<GenericRepository>()
                    .DependsOn(
                        Dependency.OnValue("connectionString", ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString),
                        Dependency.OnAppSettingsValue("databaseName", "DbName")),

                Component.For<IFoodProcessor>()
                    .ImplementedBy<FoodProcessor>(),

                Component.For<IBoardProcessor>()
                    .ImplementedBy<BoardProcessor>()
                    .DynamicParameters((DynamicParametersDelegate)GetBoardTemplates),
                    
                Component.For<BoardTemplate>()
                    .ImplementedBy<DailyMenuBoardTemplate>()
                    .Named("DailyMenuBoardTemplate"),

                Component.For<BoardTemplate>()
                    .ImplementedBy<SalatsBoardTemplate>()
                    .Named("SalatsBoardTemplate"));
        }

        /// <summary>
        /// Gets the board templates.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="parameters">The parameters.</param>
        public static void GetBoardTemplates(IKernel kernel, IDictionary parameters)
        {
            parameters["boardTemplates"] = CastleContainer.Instance.ResolveAll<BoardTemplate>();
        }
    }
}
