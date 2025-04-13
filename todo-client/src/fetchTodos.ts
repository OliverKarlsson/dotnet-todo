import { ALL_TODOS_CONTENT_ID } from "./constants";
import { TodoItem, TodoItemProps } from "./TodoItem";
import { TodosList } from "./TodosList";

const example: TodoItemProps[] = [
  { name: "Some todo", completed: true, creationDate: "2025-01-01" },
  { name: "Some todo", completed: false, creationDate: "2025-01-01" },
];

const makeTodos = (items: TodoItemProps[]) =>
  items.reduce((acc, item) => {
    return acc + TodoItem(item);
  }, "");

export const fetchTodos = () => {
  const allTodosRoot = document.getElementById(ALL_TODOS_CONTENT_ID);

  if (allTodosRoot) {
    allTodosRoot.innerHTML = TodosList({ content: makeTodos(example) });
  }
};
