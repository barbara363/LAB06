using System;
using System.Collections.Generic;
using System.Text;

namespace LAB06
{
    public class Range
    {
        private int _start;
        private int _finish;

        public int Start
        {
            get { return _start; }
            set
            {
                if (value > _finish)
                    throw new ArgumentException("Начало (start) не может быть больше конца (finish).");
                _start = value;
            }
        }

        public int Finish
        {
            get { return _finish; }
            set
            {
                if (value < _start)
                    throw new ArgumentException("Конец (finish) не может быть меньше начала (start).");
                _finish = value;
            }
        }

        public Range(int start, int finish)
        {
            if (start > finish)
                throw new ArgumentException("Ошибка: начало не может быть больше конца.");

            _start = start;
            _finish = finish;
        }

        private bool IsIntersect(Range other)
        {
            return this.Start <= other.Finish && other.Start <= this.Finish;
        }

        public static Range operator +(Range r1, Range r2)
        {
            if (!r1.IsIntersect(r2))
                throw new ArgumentException("Отрезки не пересекаются, объединить их нельзя.");

            int newStart = Math.Min(r1.Start, r2.Start);
            int newFinish = Math.Max(r1.Finish, r2.Finish);

            return new Range(newStart, newFinish);
        }

        public static Range operator -(Range r1, Range r2)
        {
            if (!r1.IsIntersect(r2))
                throw new ArgumentException("Отрезки не пересекаются, общей части нет.");

            int newStart = Math.Max(r1.Start, r2.Start);
            int newFinish = Math.Min(r1.Finish, r2.Finish);

            return new Range(newStart, newFinish);
        }

        public override string ToString()
        {
            string numbers;
            {
                var arr = Enumerable.Range(Start, Finish - Start + 1);
                numbers = string.Join(", ", arr);
            }

            return $"Range ({Start}, {Finish}), [{numbers}]";
        }
    }
}
    

