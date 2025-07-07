import { createSlice } from "@reduxjs/toolkit";

const cartSlice = createSlice({
  name: "cart",
  initialState: {
    items: [],
  },
  reducers: {
    addToCart(state, action) {
      state.items.push(action.payload);
    },
    // removeFromCart(state, action) {
    //   state.items = state.items.filter((item) => item.id !== action.payload);
    // },

    removeFromCart(state, action) {
        const index = state.items.findIndex((item) => item.id === action.payload);
        if (index !== -1) {
            state.items.splice(index, 1); // remove one item at that index
        }
        }

  },
});

export const { addToCart, removeFromCart } = cartSlice.actions;
export const cartReducer = cartSlice.reducer;
