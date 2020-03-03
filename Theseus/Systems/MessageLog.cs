using RLNET;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theseus.Systems {
    public class MessageLog {
        // Define the number of max lines to store.
        private static readonly int _maxLines = 9;

        // Use a Queue to keep track of the lines of text.
        // The first line added to the log will also be the first removed
        private readonly Queue<string> _lines;

        public MessageLog() {
            _lines = new Queue<string>();
        }

        // Add a line to the MessageLog Queue.
        public void Add(string message) {
            _lines.Enqueue(message);

            // Remove the oldest lines.
            if (_lines.Count > _maxLines) {
                _lines.Dequeue();
            }
        }

        // Draw each line of the MessageLog to the Messages console
        public void Draw(RLConsole console) {
            console.Clear();
            string[] lines = _lines.ToArray();
            for (int i = 0; i < lines.Length; i++) {
                console.Print(1, i + 1, lines[i], RLColor.White);
            }
        }
    }
}
