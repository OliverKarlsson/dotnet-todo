import { postCompleteTodo, postUndoTodo } from "./api";

export type TodoItemProps = {
  id: string;
  name: string;
  creationDate: string;
  completed: boolean;
};

type ActionButtonProps = {
  id: string;
};

const undoButton = ({ id }: ActionButtonProps) =>
  `<button onclick="undoTodo('${id}')">Undo</button>`;

const completeButton = ({ id }: ActionButtonProps) =>
  `<button onclick="completeTodo('${id}')">Complete</button>`;

export const TodoItem = ({
  name,
  creationDate,
  completed,
  id,
}: TodoItemProps) =>
  `<li>
<span class="todo-name">${name}</span>
<span class="todo-creation-date">${creationDate}</span>
<span>${completed ? `✅` : `❌`}</span>
${completed ? undoButton({ id }) : completeButton({ id })}
</li>`;

//@ts-ignore
window.undoTodo = (id) => postUndoTodo(id);

//@ts-ignore
window.completeTodo = (id) => postCompleteTodo(id);
