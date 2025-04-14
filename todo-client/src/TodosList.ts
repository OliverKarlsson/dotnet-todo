type Props = {
  content: string;
};

export const TodosList = ({ content }: Props) => `<ul>${content}</ul>`;
