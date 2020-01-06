<template>
  <v-tabs background-color="indigo" center-active show-arrows dark>
    <v-tab v-for="exam in exams" :key="exam.id">{{exam.title}}</v-tab>
    <v-tab-item v-for="exam in exams" :key="exam.id">
      <ExamItem v-bind:exam="exam"></ExamItem>
    </v-tab-item>
  </v-tabs>

  <!-- <v-carousel :show-arrows="false">
    <v-carousel-item v-for="exam in exams" :key="exam.id">
      <div>
        <ExamItem v-bind:exam="exam"></ExamItem>
      </div>
    </v-carousel-item>
  </v-carousel>-->
</template>

<script>
import ExamItem from "@/components/ExamItem.vue";
import { getFuture } from "@/axios";
export default {
  components: { ExamItem },
  data: () => ({
    exams: null
  }),

  mounted() {
    this.getFutureExam();
  },

  methods: {
    getFutureExam() {
      getFuture().then(response => {
        if (response.data.success) {
          this.exams = response.data.result;
        } else {
          console.log(response.data.result);
        }
      });
    }
  }
};
</script>
