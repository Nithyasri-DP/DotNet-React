import React, { useEffect, useState } from "react";
import { BookService } from "../services/BookService";
import BookTable from "./BookTable";
import BookForm from "./BookForm";

const BookList = () => {
    const [books, setBooks] = useState([]);
    const [selected, setSelected] = useState(null);
    const [error, setError] = useState("");

    useEffect(() => {
        loadData();
    }, []);

    const loadData = async () => {
        const data = await BookService.getAll();
        setBooks(data);
    };

    const handleAdd = async (book) => {
        try {
            const added = await BookService.add(book);            
            setBooks((prev) => [...prev, added]);
        } catch {
            setError("Failed to add book");
        }
    };

    const handleDelete = async (id) => {
        try {
            const success = await BookService.remove(id);
            if (success) {
                setBooks((prev) => prev.filter((b) => b.id !== id));
            }
        } catch {
            setError("Failed to delete book");
        }
    };

    const handleEdit = (book) => {
        setSelected(book);
    };

    const handleUpdate = async (book) => {
        try {
            const updated = await BookService.update(book);
            setBooks((prev) => prev.map((b) => (b.id === updated.id ? updated : b)));
            setSelected(null);
        } catch {
            setError("Failed to update book");
        }
    };

    return (
        <div className="container mt-4">
            <h2 className="text-center mb-4">Library Book Management</h2>

            {error && <div className="alert alert-danger">{error}</div>}

            <BookForm
                onAdd={handleAdd}
                onUpdate={handleUpdate}
                selected={selected}
            />

            <BookTable
                books={books}
                onDelete={handleDelete}
                onEdit={handleEdit}
            />
        </div>
    );
};

export default BookList;
