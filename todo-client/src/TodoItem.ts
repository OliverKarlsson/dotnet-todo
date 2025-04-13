export type TodoItemProps = {
  name: string;
  creationDate: string;
  completed: boolean;
};

export const TodoItem = ({ name, creationDate, completed }: TodoItemProps) =>
  `<li>
<span>${name}</span>
<span class="todo-creation-date">${creationDate}</span>
<span>${completed ? `✅` : `❌`}</span>
</li>`;
