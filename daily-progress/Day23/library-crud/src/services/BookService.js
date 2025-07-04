let _books = [
    { id: 1, title: "Shakespeare", author: "Romeo Juliet", genre: "Romantic" },
    { id: 2, title: "Ponniyin Selvan", author: "Kalki", genre: "History" },
];

export const BookService = {
    getAll() {
        return Promise.resolve(_books);
    },

    add(book) {
        const newBook = { ...book, id: Math.max(0, ..._books.map(b => b.id)) + 1 };
        return Promise.resolve(newBook); 
    },

    update(book) {
        const index = _books.findIndex(b => b.id === book.id);
        if (index !== -1) {
            _books[index] = book;
        }
        return Promise.resolve(book);
    },

    remove(id) {
        const initialLength = _books.length;
        _books = _books.filter(b => b.id !== id);
        return Promise.resolve(_books.length !== initialLength);
    }
};
