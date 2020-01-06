<template>
  <v-carousel :show-arrows="false">
    <v-carousel-item v-for="exam in exams" :key="exam.id">
        <div>
            <ExamItem v-bind:exam="exam" ></ExamItem>
        </div>      
    </v-carousel-item>
  </v-carousel>
</template>

<script>
import ExamItem from "@/components/ExamItem.vue";
export default {
  components: { ExamItem },
  data: () => ({
    exams: null
  }),

  mounted() {
      this.exams = [
          { id: 1, title: "Линал"},
          { id: 2, title: "Матан"}
      ]
  }
};
</script>
