import { postCreateTodo } from "./api";

export const CreateTodo = () =>
  `<button onclick="promptForTodo()">Create a new todo</button>`;

const promptForTodo = () => {
  const name = prompt("What do you want to do?");

  if (name === "") {
    alert("Sorry, the name must not be an empty string");
  } else if (name !== null) {
    postCreateTodo(name).then(() => {
      alert(`Successfully added "${name}"`);
      window.location.reload();
    });
  }
};

//@ts-ignore
window.promptForTodo = promptForTodo;
