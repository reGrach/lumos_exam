<template>
  <div>
    <v-tabs background-color="indigo" center-active show-arrows dark>
      <v-tab v-for="exam in exams" :key="exam.id">{{exam.title}}</v-tab>
      <v-tab-item v-for="exam in exams" :key="exam.id">
        <ExamItem v-bind:exam="exam"></ExamItem>
      </v-tab-item>
    </v-tabs>
    <v-alert v-model="alert" dense outlined type="error" close-text="Close Alert" dismissible>
      <strong>{{error}}</strong>
    </v-alert>
  </div>
</template>

<script>
import ExamItem from "@/components/ExamItem.vue";
import { getFuture } from "@/axios";
export default {
  components: { ExamItem },
  data: () => ({
    exams: null,
    error: null,
    alert: true
  }),

  mounted() {
    this.getFutureExam();
  },

  methods: {
    getFutureExam() {
      getFuture()
        .then(response => {
          if (response.data.success) {
            this.exams = response.data.result;
          } else {
            this.error = response.data.result;
          }
        })
        .catch(() => {
          this.error = "Фатальная ошибка. Надо Гере сказать!";
        });
    }
  }
};
</script>
