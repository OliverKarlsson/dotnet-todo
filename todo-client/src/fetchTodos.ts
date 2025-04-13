import { getActiveTodos, getAllTodos, getCompletedTodos } from "./api";
import {
  ACTIVE_TODOS_CONTENT_ID,
  ALL_TODOS_CONTENT_ID,
  COMPLETED_TODOS_CONTENT_ID,
} from "./constants";
import { Loader } from "./Loader";
import { TodoItem, TodoItemProps } from "./TodoItem";
import { TodosList } from "./TodosList";

const makeTodos = (items: TodoItemProps[]) =>
  items.reduce((acc, item) => {
    return acc + TodoItem(item);
  }, "");

const renderFetchedTodo = async (
  fetcher: () => Promise<TodoItemProps[]>,
  contentId: string
) => {
  const todosContentRoot = document.getElementById(contentId);

  if (todosContentRoot) {
    todosContentRoot.innerHTML = Loader();

    const todos = await fetcher();

    todosContentRoot.innerHTML = TodosList({ content: makeTodos(todos) });
  }
};

export const fetchTodos = async () => {
  await Promise.all([
    renderFetchedTodo(getAllTodos, ALL_TODOS_CONTENT_ID),
    renderFetchedTodo(getActiveTodos, ACTIVE_TODOS_CONTENT_ID),
    renderFetchedTodo(getCompletedTodos, COMPLETED_TODOS_CONTENT_ID),
  ]);
};
