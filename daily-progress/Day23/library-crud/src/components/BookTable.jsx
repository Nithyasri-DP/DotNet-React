import React from "react";

const BookTable = ({ books, onDelete, onEdit }) => {
    return (
        <table className="table table-bordered">
            <thead className="thead-dark">
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Genre</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {books.length === 0 ? (
                    <tr>
                        <td colSpan="4" className="text-center">No books available</td>
                    </tr>
                ) : (
                    books.map((book) => (
                        <tr key={book.id}>
                            <td>{book.title}</td>
                            <td>{book.author}</td>
                            <td>{book.genre}</td>
                            <td>
                                <button className="btn btn-primary btn-sm me-2" onClick={() => onEdit(book)}>Edit</button>
                                <button className="btn btn-danger btn-sm" onClick={() => onDelete(book.id)}>Delete</button>
                            </td>
                        </tr>
                    ))
                )}
            </tbody>
        </table>
    );
};

export default BookTable;
