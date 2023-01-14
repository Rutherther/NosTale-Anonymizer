//
//  IAnonymizer.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Anonymizer;

/// <summary>
/// An anonymizer used in movers, to anonymize.
/// </summary>
public interface IAnonymizer
{
    /// <summary>
    /// Anonymize the given name.
    /// </summary>
    /// <param name="name">The name to anonymize.</param>
    /// <returns>An anonymized name.</returns>
    public string AnonymizeName(string name);

    /// <summary>
    /// Anonymize the given id.
    /// </summary>
    /// <param name="id">The id to anonymize.</param>
    /// <returns>An anonymized id.</returns>
    public long AnonymizeId(long id);

    /// <summary>
    /// Anonymize the given id.
    /// </summary>
    /// <param name="id">The id to anonymize.</param>
    /// <returns>An anonymized id.</returns>
    public int AnonymizeId(int id);

    /// <summary>
    /// Anonymize the given id.
    /// </summary>
    /// <param name="id">The id to anonymize.</param>
    /// <returns>An anonymized id.</returns>
    public short AnonymizeId(short id);

    /// <summary>
    /// Anonymize id and a name.
    /// </summary>
    /// <param name="id">The id to anonymize.</param>
    /// <param name="name">The name to anonymize.</param>
    /// <returns>An anonymized tuple, name and id.</returns>
    public (long Id, string Name) Anonymize(long id, string name);
}