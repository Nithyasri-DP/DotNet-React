import React, { useEffect, useState } from "react";

const BookForm = ({ onAdd, onUpdate, selected }) => {
    const [book, setBook] = useState({
        title: "",
        author: "",
        genre: ""
    });

    useEffect(() => {
        if (selected) {
            setBook(selected);
        } 
        else {
            setBook({ title: "", author: "", genre: "" });
        }
    }, [selected]);

    const handleChange = (e) => {
        setBook({ ...book, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        if (!book.title || !book.author || !book.genre) {
            alert("All fields are required");
            return;
        }
        if (selected) {
            onUpdate(book);
        } else {
            onAdd(book);
        }
        setBook({ title: "", author: "", genre: "" });
    };

    return (
        <form onSubmit={handleSubmit} className="mb-4">
            <div className="row">
                <div className="col">
                    <input
                        type="text"
                        name="title"
                        className="form-control"
                        placeholder="Title"
                        value={book.title}
                        onChange={handleChange}
                    />
                </div>
                <div className="col">
                    <input
                        type="text"
                        name="author"
                        className="form-control"
                        placeholder="Author"
                        value={book.author}
                        onChange={handleChange}
                    />
                </div>
                <div className="col">
                    <input
                        type="text"
                        name="genre"
                        className="form-control"
                        placeholder="Genre"
                        value={book.genre}
                        onChange={handleChange}
                    />
                </div>
                <div className="col">
                    <button type="submit" className="btn btn-success w-100">
                        {selected ? "Update" : "Add"}
                    </button>
                </div>
            </div>
        </form>
    );
};

export default BookForm;
