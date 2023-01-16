//
//  ServiceCollectionExtensions.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Anonymizer.Filters;
using Anonymizer.Movers;
using Anonymizer.Movers.Basic;
using Microsoft.Extensions.DependencyInjection;
using NosSmooth.Packets;
using NosSmooth.Packets.Client;
using NosSmooth.Packets.Client.Battle;
using NosSmooth.Packets.Client.Inventory;
using NosSmooth.Packets.Client.Mates;
using NosSmooth.Packets.Server.Battle;
using NosSmooth.Packets.Server.Buffs;
using NosSmooth.Packets.Server.Buffs.Generated;
using NosSmooth.Packets.Server.Character;
using NosSmooth.Packets.Server.Chat;
using NosSmooth.Packets.Server.Entities;
using NosSmooth.Packets.Server.Families;
using NosSmooth.Packets.Server.Groups;
using NosSmooth.Packets.Server.Inventory;
using NosSmooth.Packets.Server.Login;
using NosSmooth.Packets.Server.Maps;
using NosSmooth.Packets.Server.Mates;
using NosSmooth.Packets.Server.Raids;
using NosSmooth.Packets.Server.UI;

namespace Anonymizer.Extensions;

/// <summary>
/// An extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds anonymizer's <see cref="PacketProcessor"/>, <see cref="IAnonymizer"/>'s default implementation,
    /// <see cref="HeaderFilter"/> and basic movers (moving entity ids and names).
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddAnonymizer(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddSingleton<PacketProcessor>()
            .AddSingleton<IAnonymizer, DefaultAnonymizer>()
            .AddTransient<IFilter, HeaderFilter>()
            .AddTransient<IFilter, MessageFilter>()
            .AddBasicMovers();

    /// <summary>
    /// Adds movers that move entity id and name.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddBasicMovers(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddMover<BsPacketMover, BsPacket>()
            .AddMover<BfEPacketMover, BfEPacket>()
            .AddMover<CtPacketMover, CtPacket>()
            .AddMover<DmPacketMover, DmPacket>()
            .AddMover<RcPacketMover, RcPacket>()
            .AddMover<BfPacketMover, BfPacket>()
            .AddMover<SayiPacketMover, SayiPacket>()
            .AddMover<SayitemtPacketMover, SayitemtPacket>()
            .AddMover<SaytPacketMover, SaytPacket>()
            .AddMover<SpkPacketMover, SpkPacket>()
            .AddMover<RestPacketMover, RestPacket>()
            .AddMover<RaidfhpPacketMover, RaidfhpPacket>()
            .AddMover<RaidfmpPacketMover, RaidfmpPacket>()
            .AddMover<CtlPacketMover, CtlPacket>()
            .AddMover<SuctlPacketMover, SuctlPacket>()
            .AddMover<PtctlPacketMover, PtctlPacket>()
            .AddMover<ThrowPacketMover, ThrowPacket>()
            .AddMover<TpPacketMover, TpPacket>()
            .AddMover<CharScPacketMover, CharScPacket>()
            .AddMover<DiePacketMover, DiePacket>()
            .AddMover<CInfoPacketMover, CInfoPacket>()
            .AddMover<CModePacketMover, CModePacket>()
            .AddMover<CondPacketMover, CondPacket>()
            .AddMover<DropPacketMover, DropPacket>()
            .AddMover<GetPacketMover, GetPacket>()
            .AddMover<GidxPacketMover, GidxPacket>()
            .AddMover<InPacketMover, InPacket>()
            .AddMover<MvPacketMover, MovePacket>()
            .AddMover<NRunPacketMover, NRunPacket>()
            .AddMover<OutPacketMover, OutPacket>()
            .AddMover<PairyPacketMover, PairyPacket>()
            .AddMover<PinitPacketMover, PinitPacket>()
            .AddMover<PstPacketMover, PstPacket>()
            .AddMover<RaidPacketMover, RaidPacket>()
            .AddMover<RbossPacketMover, RbossPacket>()
            .AddMover<RdlstPacketMover, RdlstPacket>()
            .AddMover<RdlstfPacketMover, RdlstfPacket>()
            .AddMover<SayPacketMover, SayPacket>()
            .AddMover<StPacketMover, StPacket>()
            .AddMover<SuPacketMover, SuPacket>()
            .AddMover<TwkPacketMover, TwkPacket>()
            .AddMover<AtPacketMover, AtPacket>()
            .AddMover<EqPacketMover, EqPacket>()
            .AddMover<NcifPacketMover, NcifPacket>()
            .AddMover<RevivePacketMover, RevivePacket>()
            .AddMover<TitinfoPacketMover, TitinfoPacket>()
            .AddMover<UPetPacketMover, UsePetSkillPacket>()
            .AddMover<UPPacketMover, UsePartnerSkillPacket>()
            .AddMover<USPacketMover, UseSkillPacket>()
            .AddMover<CListPacketMover, CListPacket>();

    /// <summary>
    /// Adds movers that move players morphs, classes, sex, stats, weapons.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddAdvancedMovers(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }

    /// <summary>
    /// Add mover for the given type.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <typeparam name="TMover">The mover type.</typeparam>
    /// <typeparam name="TPacket">The packet type.</typeparam>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddMover<TMover, TPacket>(this IServiceCollection serviceCollection)
        where TMover : class, IMover<TPacket>
        where TPacket : class, IPacket
        => serviceCollection
            .Configure<RegisteredMovers>(rm => rm.AddMover<TPacket>())
            .AddTransient<IMover, TMover>()
            .AddTransient<IMover<TPacket>, TMover>();
}