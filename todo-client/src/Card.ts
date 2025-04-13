type CardProps = {
  title: string;
  contentId: string;
};

export const Card = ({ title, contentId }: CardProps) => {
  return `
    <div class="card">
        <h2>${title}</h2>
        <div id="${contentId}"><span class="loader"></span></div>
      </div>
    `;
};
