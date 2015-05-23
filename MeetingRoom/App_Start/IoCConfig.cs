using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akka.Actor;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using MeetingRoom.Actors;
using MeetingRoom.Controllers;

namespace MeetingRoom.App_Start
{
	public class IoCConfig
	{
		public static void BuildUpContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterType<HomeController>().
					WithParameters(new [] {
						new ResolvedParameter((p,c) => p.Name == "LiveUpdateSpeaker", (p,c) => c.ResolveNamed<IActorRef>("LiveUpdateSpeaker")),
						new ResolvedParameter((p,c) => p.Name == "PersistUpdateSpeaker", (p,c) => c.ResolveNamed<IActorRef>("PersistUpdateSpeaker")),
						new ResolvedParameter((p,c) => p.Name == "ActionBotSpeaker", (p,c) => c.ResolveNamed<IActorRef>("ActionBotSpeaker")),
						new ResolvedParameter((p,c) => p.Name == "EmailUpdateSpeaker", (p,c) => c.ResolveNamed<IActorRef>("EmailUpdateSpeaker"))//,
					});

			var system = ActorSystem.Create("MeetingRoom");

			builder.RegisterInstance(system.ActorOf<LiveUpdateActor>("speaker")).As<IActorRef>().Named<IActorRef>("LiveUpdateSpeaker");
			builder.RegisterInstance(system.ActorOf<EmailUpdateActor>("emailer")).As<IActorRef>().Named<IActorRef>("EmailUpdateSpeaker");
			builder.RegisterInstance(system.ActorOf<ActionBotActor>("actionbot")).As<IActorRef>().Named<IActorRef>("ActionBotSpeaker");
			builder.RegisterInstance(system.ActorOf<PersistUpdateActor>("saver")).As<IActorRef>().Named<IActorRef>("PersistUpdateSpeaker");

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}