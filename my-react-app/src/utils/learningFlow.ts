import type { Vocabulary } from "../types/api";

export type LearningStep = "flashcard" | "conversation" | "word" | "reading";

export function getLearningSteps(topic: Vocabulary): LearningStep[] {
  const steps: LearningStep[] = [];
  const hasItems = topic.vocabularyItems.length > 0;

  if (hasItems) steps.push("flashcard");
  if (topic.conversation !== null) steps.push("conversation");
  if (hasItems) steps.push("word");
  if (topic.reading !== null) steps.push("reading");

  return steps;
}

export function getStepPath(topicId: string | number, step: LearningStep): string {
  switch (step) {
    case "flashcard":
      return `/topics/${topicId}/falastcard`;
    case "conversation":
      return `/topics/${topicId}/practice`;
    case "word":
      return `/topics/${topicId}/word`;
    case "reading":
      return `/topics/${topicId}/reading`;
  }
}

export function getNextStepPath(topic: Vocabulary, current: LearningStep): string {
  const steps = getLearningSteps(topic);
  const currentIndex = steps.indexOf(current);

  if (currentIndex === -1 || currentIndex === steps.length - 1) {
    return `/topics/${topic.id}`;
  }

  return getStepPath(topic.id, steps[currentIndex + 1]);
}
