# bulgarianize-dotnet

.NET port of the Ruby [bulgarianize](https://github.com/skanev/bulgarianize).

A small collection of niceness for localizing your applications in Bulgarian.
If the following text doesn't make any sense, you probably won't need the gem.

На български
------------

`bulgarianize` представлява малка колекция от решения на всякакви проблеми,
които изникват при писане на софтуер на български. Или поне тези, с които
авторът му се е сблъскал.

Функционалността включва (и вероятно е лимитирана до):

(Цели) числа словом
-------------------

Проста хватка:
  
    1.AsWords()           # едно
    42.AsWords()          # четиридесет и две
    1_024.AsWords()       # хиляда двадесет и четири
  
Поради граматическа особеност на българския език се поддържа следното:

    1.AsWords(GrammarGender.Male)    # един
    1.AsWords(GrammarGender.Female)  # една
    1.AsWords(GrammarGender.Neuter)  # едно
    42.AsWords(GrammarGender.Male)   # четиридесет и два

По подразбиране родът е среден.

Copyright
---------

Copyright (c) 2019 Vladislav Hadzhiyski. See LICENSE for details.