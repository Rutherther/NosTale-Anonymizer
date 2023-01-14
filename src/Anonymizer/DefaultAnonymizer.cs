//
//  DefaultAnonymizer.cs
//
//  Copyright (c) František Boháček. All rights reserved.
//  Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Anonymizer;

/// <inheritdoc />
public class DefaultAnonymizer : IAnonymizer
{
    private readonly Random _random;
    private readonly HashSet<long> _generated;
    private readonly Dictionary<long, long> _ids;
    private readonly Dictionary<string, string> _names;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultAnonymizer"/> class.
    /// </summary>
    public DefaultAnonymizer()
    {
        _random = new Random();
        _generated = new HashSet<long>();
        _ids = new Dictionary<long, long>();
        _names = new Dictionary<string, string>();
    }

    /// <inheritdoc />
    public string AnonymizeName(string name)
    {
        if (!_names.ContainsKey(name))
        {
            var generatedName = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                generatedName += (char)_random.Next('A', 'Z');
            }

            _names[name] = generatedName;
        }

        return _names[name];
    }

    /// <inheritdoc />
    public long AnonymizeId(long id)
    {
        if (!_ids.ContainsKey(id))
        {
            var generated = _random.Next();
            if (_generated.Contains(generated))
            {
                return AnonymizeId(id);
            }

            _ids[id] = generated;
            _generated.Add(generated);

        }

        return _ids[id];
    }

    /// <inheritdoc />
    public int AnonymizeId(int id)
    {
        if (!_ids.ContainsKey(id))
        {
            var generated = _random.Next() & 0xFFFFFFFF;
            if (_generated.Contains(generated))
            {
                return AnonymizeId(id);
            }

            _ids[id] = generated;
            _generated.Add(generated);

        }

        return (int)_ids[id];
    }

    /// <inheritdoc />
    public short AnonymizeId(short id)
    {
        if (!_ids.ContainsKey(id))
        {
            var generated = _random.Next() & 0xFFFF;
            if (_generated.Contains(generated))
            {
                return AnonymizeId(id);
            }

            _ids[id] = generated;
            _generated.Add(generated);

        }

        return (short)_ids[id];
    }

    /// <inheritdoc />
    public (long Id, string Name) Anonymize(long id, string name)
        => (AnonymizeId(id), AnonymizeName(name));
}