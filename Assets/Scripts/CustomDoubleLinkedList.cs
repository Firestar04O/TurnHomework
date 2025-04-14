using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDoubleLinkedList<T> : DoubleLinkedList<T>
{
    private Node<T> peak;
    public Node<T> Peak => peak;
    public void MovePeakNext()
    {
        if (peak != null && peak.Next != null)
            peak = peak.Next;
    }
    public void MovePeakPrev()
    {
        if (peak != null && peak.Prev != null)
            peak = peak.Prev;
    }
    public override void Add(T value)
    {
        if (peak != null && peak != last)
        {
            // Eliminar todos los nodos después de Peak
            Node<T> temp = peak.Next;
            while (temp != null)
            {
                Node<T> toDelete = temp;
                temp = temp.Next;
                toDelete.SetPrev(null);
                toDelete.SetNext(null);
            }
            peak.SetNext(null);
            last = peak;
        }
        Node<T> newNode = new Node<T>(value);
        if (head == null)
        {
            head = last = peak = newNode;
        }
        else
        {
            last.SetNext(newNode);
            newNode.SetPrev(last);
            last = newNode;
            peak = newNode;
        }
    }
    //public Node<T> Peek()
    //{
    //    return head;
    //}
    //public Node<T> Last()
    //{
    //    return last;
    //}
    //public Node<T> PeekNext(Node<T> current)
    //{
    //    return current.Next;
    //}
    //public Node<T> PeekPrev(Node<T> current)
    //{
    //    return current.Prev;
    //}
    //public Node<T> PeekAt(int index)
    //{
    //    return Seek(index);
    //}
}
