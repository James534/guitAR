using System.Collections;
using System.Collections.Generic;

public class SongLibary {

    public static List<List<Note>> getJingleBells()
    {
        List < List < Note > > tabs = new List<List<Note>>();
        //jingle bells
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 2) });

        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 2) });

        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 3, 1) });
        tabs.Add(new List<Note> { new Note(2, 1, 1) });
        tabs.Add(new List<Note> { new Note(2, 3, 1) });

        tabs.Add(new List<Note> { new Note(1, 0, 4), new Note(2, 1, 4), new Note(3, 0, 4) });

        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });

        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });

        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(2, 3, 1) });
        tabs.Add(new List<Note> { new Note(2, 3, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });

        tabs.Add(new List<Note> { new Note(2, 3, 2) });
        tabs.Add(new List<Note> { new Note(1, 3, 2), new Note(2, 0, 2), new Note(3, 0, 2) });

        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 2) });

        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 2) });

        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 3, 1) });
        tabs.Add(new List<Note> { new Note(2, 1, 1) });
        tabs.Add(new List<Note> { new Note(2, 3, 1) });

        tabs.Add(new List<Note> { new Note(1, 0, 4), new Note(2, 1, 4), new Note(3, 0, 4) });

        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });

        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });
        tabs.Add(new List<Note> { new Note(1, 0, 1) });

        tabs.Add(new List<Note> { new Note(1, 3, 1) });
        tabs.Add(new List<Note> { new Note(1, 3, 1) });
        tabs.Add(new List<Note> { new Note(1, 1, 1) });
        tabs.Add(new List<Note> { new Note(2, 3, 1) });

        tabs.Add(new List<Note> { new Note(2, 1, 2) });
        tabs.Add(new List<Note> { new Note(1, 0, 2), new Note(2, 1, 2), new Note(3, 0, 2) });

        return tabs;
    }
}
