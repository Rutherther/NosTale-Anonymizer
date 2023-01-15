# NosTale-Anonymizer
A tool for NosTale packet files that filters specified packets and replaces ids, names to make the result anonymous.

Currently only files are supported. I am planning to make this work with [NosSmooth.Local](https://github.com/Rutherther/NosSmooth.Local).

## What packets are supported
Anonymizer uses [NosSmooth.Packets](https://github.com/Rutherther/NosSmooth), so all packets NosSmooth supports may be moved.

There are two filters for filtering by header and filtering text messages (;, :, /). There are some default headers that are removed,
because these packets allow for identification and are not yet supported.

In case you think there is a packet that may identify anyone that is not handled, 

By default, the packets that may be anonymized, are:
- at
- bs
- c_info
- c_list
- c_mode
- cond
- drop
- eq
- get
- gidx
- in
- mv
- ncif
- n_run
- out
- pairy
- pinit
- pst
- raid
- raidf
- rboss
- rdlstf
- rdlst
- revive
- say
- st
- su
- titinfo
- twk
- u_pet
- u_p
- u_s

The only things anonymized in these are ids and names.
Anonymizing other things such as level, hero level, class, weapon, inventory items will be supported in the future.

## Anonymization process
Anonymization happens in `IAnonymizer`, there is a default implementation `DefaultAnonymizer` that may be replaced. The default anonymizer
just generates random numbers and names of length 10. It could be better to use a list of names and choose from that to make the names
more user friendly.

## Future features

- Add support for [NosSmooth.Local](https://github.com/Rutherther/NosSmooth.Local). Make a deanonymizer. Anonymize the packets upon receiving and deanonymize them upon sending. 
- Add support for all packets that may identify the user.
- Add support for anonymizing other things apart from id, names.
