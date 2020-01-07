<template>
  <div>
    <v-container>
      <v-row dense>
        <v-col v-for="(quest, i) in questions" :key="quest.id" cols="12">
          <QuestionItem v-bind:quest="quest" v-bind:number="i+1"></QuestionItem>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import QuestionItem from "@/components/QuestionItem.vue"
export default {
  components: { QuestionItem },
  props: {
    exam: Object
  },
  data: () => ({
    questions: null
  }),

  mounted() {
    this.questions = this.exam.questions;
  }
};
</script>
